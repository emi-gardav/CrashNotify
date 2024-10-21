;; title: smart-insurance
;; version: v1.0
;; summary: Smart Auto Insurance Contract
;; description: This smart contract implements a car insurance system on the Stacks blockchain.
;;
;; data vars
(define-data-var insurance-pool uint u0)
(define-data-var admin principal tx-sender)

;; data maps
(define-map driver-policies principal {score: uint, premium: uint, active: bool})

;; public functions

(define-public (register-driver (initial-premium uint))
    (let ((caller tx-sender))
    (asserts! (is-none (map-get? driver-policies caller)) (err u1))
    (map-set driver-policies caller {score: u50, premium: initial-premium, active: true})
    (ok true)))

(define-public (update-driver-score (new-score uint))
    (let ((caller tx-sender)
    (current-policy (unwrap! (map-get? driver-policies caller) (err u2))))
    (asserts! (get active current-policy) (err u3))
    (map-set driver-policies caller (merge current-policy {score: new-score}))
    (ok true)))

(define-public (add-premium (driver principal) (amount uint))
    (let ((caller tx-sender)
    (current-policy (unwrap! (map-get? driver-policies driver) (err u111))))
    (asserts! (is-eq caller (var-get admin)) (err u112))
    (asserts! (get active current-policy) (err u113))
    (let ((new-premium (+ (get premium current-policy) amount)))
    (map-set driver-policies driver (merge current-policy {premium: new-premium}))
    (ok new-premium))))

(define-public (apply-new-premium)
    (let ((caller tx-sender)
    (current-policy (unwrap! (map-get? driver-policies caller) (err u5))))
    (asserts! (get active current-policy) (err u6))
    (let ((new-premium (unwrap! (calculate-premium caller) (err u7))))
    (map-set driver-policies caller (merge current-policy {premium: new-premium}))
    (ok new-premium))))

(define-public (pay-premium (amount uint))
    (let ((caller tx-sender)
    (current-policy (unwrap! (map-get? driver-policies caller) (err u8))))
    (asserts! (get active current-policy) (err u9))
    (let ((current-premium (get premium current-policy)))
    (asserts! (<= amount current-premium) (err u11))
    (try! (stx-transfer? amount caller (as-contract tx-sender)))
    (var-set insurance-pool (+ (var-get insurance-pool) amount))
    (let ((new-premium (- current-premium amount)))
    (map-set driver-policies caller (merge current-policy {premium: new-premium}))
    (ok amount)))))

(define-public (claim-insurance (amount uint))
    (let ((caller tx-sender)
    (current-policy (unwrap! (map-get? driver-policies caller) (err u8))))
    (asserts! (get active current-policy) (err u9))
    (asserts! (<= amount (var-get insurance-pool)) (err u10))
    (try! (as-contract (stx-transfer? amount tx-sender caller)))
    (var-set insurance-pool (- (var-get insurance-pool) amount))
    (ok amount)))

(define-public (cancel-policy)
    (let ((caller tx-sender)
    (current-policy (unwrap! (map-get? driver-policies caller) (err u101))))
    (asserts! (get active current-policy) (err u102))
    (map-set driver-policies caller (merge current-policy {active: false}))
    (ok true)))

(define-public (reactivate-policy)
    (let ((caller tx-sender)
    (current-policy (unwrap! (map-get? driver-policies caller) (err u103))))
    (asserts! (not (get active current-policy)) (err u104))
    (map-set driver-policies caller (merge current-policy {active: true}))
    (ok true)))

(define-public (adjust-insurance-pool (amount uint))
    (begin
    (asserts! (is-eq tx-sender (var-get admin)) (err u105))
    (var-set insurance-pool (+ (var-get insurance-pool) amount))
    (ok (var-get insurance-pool))))

(define-public (update-premium (new-premium uint))
    (let ((caller tx-sender)
    (current-policy (unwrap! (map-get? driver-policies caller) (err u107))))
    (asserts! (get active current-policy) (err u108))
    (map-set driver-policies caller (merge current-policy {premium: new-premium}))
    (ok new-premium)))

(define-public (report-accident)
    (let ((caller tx-sender)
    (current-policy (unwrap! (map-get? driver-policies caller) (err u109))))
    (asserts! (get active current-policy) (err u110))
    (ok true)))

;; read only functions

(define-read-only (get-current-premium (driver principal))
    (match (map-get? driver-policies driver)
    policy (ok (get premium policy))
    (err u300)))

(define-read-only (calculate-premium (driver principal))
    (let ((current-policy (unwrap! (map-get? driver-policies driver) (err u4))))
    (let ((base-premium (get premium current-policy))
    (current-score (get score current-policy)))
    (if (is-eq current-score u0)
    (ok (* base-premium u2))  ;; Si el score es 0, doblamos la prima
    (ok (/ (* base-premium u100) (- u100 current-score)))))))

(define-read-only (get-insurance-pool-balance)
    (ok (var-get insurance-pool)))

(define-read-only (get-driver-policy (driver principal))
    (ok (unwrap! (map-get? driver-policies driver) (err u100))))

(define-read-only (calculate-discount (driver principal))
    (let ((policy (unwrap! (map-get? driver-policies driver) (err u106))))
    (ok (/ (* (get score policy) u10) u100))))

;; private functions
;;